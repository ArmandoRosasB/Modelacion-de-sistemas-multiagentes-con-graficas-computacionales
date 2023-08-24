from matplotlib.colors import ListedColormap
from mesa import Agent, Model
from mesa.model import Model
import numpy as np
import seaborn as sns

from mesa.time import BaseScheduler
from mesa.datacollection import DataCollector
from mesa.space import SingleGrid

import matplotlib
import matplotlib.pyplot as plt
import matplotlib.animation as animation
plt.rcParams["animation.html"] = "jshtml"
matplotlib.rcParams['animation.embed_limit'] = 2**128

import random


class Fish(Agent):
    def __init__(self, id: int, model: Model) -> None:
        super().__init__(id, model)

        self.type = 0 # Fish
        self.fertility_threshold = 4
        self.energy = 20

    def step(self) -> None:
        if self.energy == 0:
            self.model.grid.remove_agent(self)
            self.model.schedule.remove(self)
            return

        neighborhood = set(self.model.grid.get_neighborhood(self.pos, moore=False, include_center=False))
        neighbors_pos = set( neighbor.pos for neighbor in self.model.grid.get_neighbors(self.pos, moore=False, include_center=False))
        
        available_movements = neighborhood.difference(neighbors_pos)

        if len(available_movements) > 0:
            child = None
            if self.fertility_threshold == 0:
                child = self.pos 
                self.fertility_threshold = 5
                
            self.model.grid.move_agent(self, list(available_movements)[np.random.choice([i for i in range(len(available_movements))])])  

            if child is not None:

                creature = Fish(self.model.id, self.model)
                
                self.model.grid.place_agent(creature, child)
                self.model.schedule.add(creature)
                self.model.id += 1

        self.fertility_threshold -= 1
        self.energy -= 1
 




class Shark(Agent):
    def __init__(self, id: int, model: Model) -> None:
        super().__init__(id, model)

        self.type = 1 # Shark
        self.fertility_threshold = 12
        self.energy = 3

    def step(self) -> None:
        if self.energy == 0:
            self.model.grid.remove_agent(self)
            self.model.schedule.remove(self)

            return

        fish = [creature for creature in self.model.grid.get_neighbors(self.pos, moore=False, include_center=False) if creature.type == 0]
        sharks = [creature for creature in self.model.grid.get_neighbors(self.pos, moore=False, include_center=False) if creature.type == 1]


        child = None

        if self.fertility_threshold == 0:
                    child = self.pos
                    self.fertility_threshold = 13
        
        if len(fish) > 0: # Si existen peces alrededor
            prey = fish[np.random.choice([i for i in range(len(fish))])]
            aux = prey.pos
            self.model.grid.remove_agent(prey)
            self.model.schedule.remove(prey)
            
            self.model.grid.move_agent(self, aux)

            self.energy += 4
        
        elif len(sharks) < 4:
            available_movements = set(neighbor for neighbor in (self.model.grid.get_neighborhood(self.pos, moore=False, include_center=False))).difference(set(shark.pos for shark in sharks))
            if len(available_movements) > 0:    
                self.model.grid.move_agent(self, list(available_movements)[np.random.choice([i for i in range(len(available_movements))])])
        
             
        else :
            child = None


        self.fertility_threshold -= 1
        self.energy -= 1
                
        
        if child is not None:
            creature = Shark(self.model.id, self.model)
            self.model.grid.place_agent(creature, child)
            self.model.schedule.add(creature)

            self.model.id += 1
      



def get_grid(model):
    grid = np.zeros( (model.grid.width, model.grid.height) )
    for (content, (x, y)) in model.grid.coord_iter():
        if content:
            if content.type == 0:
                grid[x][y] = 0
            elif content.type == 1:
                grid[x][y] = 1
        else:
            grid[x][y] = 2


    return grid


class WaTor(Model):
    def __init__(self, width: int, height: int, sharks: int, fish: int):
        self.grid = SingleGrid(width, height, torus=True)
        self.schedule = BaseScheduler(self)
        self.datacollector = DataCollector( model_reporters=
            {"Grid": get_grid}
        )
        self.id = 0
        
        while self.grid.exists_empty_cells() and sharks > 0:
            shark = Shark(self.id, self)
            self.grid.move_to_empty(shark)
            self.schedule.add(shark)

            sharks -= 1
            self.id += 1
        
        while self.grid.exists_empty_cells() and fish > 0:
            _fish = Fish(self.id, self)
            self.grid.move_to_empty(_fish)
            self.schedule.add(_fish)

            fish -= 1
            self.id += 1
        
    
    def step(self):
        self.datacollector.collect(self)
        self.schedule.step()


MAX_ITERATIONS = 550
WIDTH = 75
HEIGHT = 50
SHARKS = 40
FISH = 160

model = WaTor(WIDTH, HEIGHT, SHARKS, FISH)

for i in range(MAX_ITERATIONS):
    model.step()


all_grid = model.datacollector.get_model_vars_dataframe() # Arreglo de matrices

fig, axis = plt.subplots(figsize= (50, 50))
axis.set_xticks([])
axis.set_yticks([])

oceano = ['#FF5F1F', '#000080', '#3CDFFF']
my_cmap = ListedColormap(sns.color_palette(oceano).as_hex())

patch = plt.imshow(all_grid.iloc[0][0], cmap=my_cmap)


def animate(i):
    patch.set_data(all_grid.iloc[i][0])
anim = animation.FuncAnimation(fig, animate, frames = MAX_ITERATIONS)



plt.show()



