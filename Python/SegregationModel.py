# Importamos las clases que se requieren para manejar los agentes (Agent) y su entorno (Model).
# Cada modelo puede contener múltiples agentes.
from mesa import Agent, Model 

# Debido a que necesitamos que existe un solo agente por celda, elegimos ''SingleGrid''.
from mesa.space import SingleGrid

# Con ''RandomActivation'', hacemos que todos los agentes se activen ''al mismo tiempo''.
from mesa.time import RandomActivation

# Haremos uso de ''DataCollector'' para obtener información de cada paso de la simulación.
from mesa.datacollection import DataCollector

# matplotlib lo usaremos crear una animación de cada uno de los pasos del modelo.
# %matplotlib inline
import matplotlib
import matplotlib.pyplot as plt
import matplotlib.animation as animation
plt.rcParams["animation.html"] = "jshtml"
matplotlib.rcParams['animation.embed_limit'] = 2**128

# Importamos los siguientes paquetes para el mejor manejo de valores numéricos.
import numpy as np
import pandas as pd

# Definimos otros paquetes que vamos a usar para medir el tiempo de ejecución de nuestro algoritmo.
import time
import datetime

class SegregationAgent(Agent):
    def __init__(self, id, model, type = 0, threshold = 0.30):
        super().__init__(id, model)
        self.type = type
        self.threshold = threshold

    def step(self):
        neighbors = self.model.grid.get_neighbors(self.pos, moore = True, include_center = False)

        count = 0
        for agent in neighbors:
            if agent.type == self.type:
                count += 1

        percentage = 0.0
        if len(neighbors) > 0:
            percentage = float(count) / float(len(neighbors))

        if percentage < self.threshold:
            self.model.grid.move_to_empty(self)



def get_grid(mode):
    grid = np.zeros( (model.grid.width, model.grid.height))
    for (content, (x, y)) in model.grid.coord_iter():
            if content != None:
                grid[x][y] = content.type
            else:
                 grid[x][y] = 2
                
    return grid


class SegregationModel(Model):
    def __init__(self, width, height, empty_cells = 0.2, threshold = 0.3):
        self.grid = SingleGrid(width, height, torus = False)
        self.schedule = RandomActivation(self)
        self.datacollector = DataCollector(
            model_reporters = {"Grid": get_grid })

        id = 0
        num_agents = int ((width * height) * (1 - empty_cells))
        while self.grid.exists_empty_cells():   
            agent = SegregationAgent(id, self, np.random.choice([0, 1]), threshold)
            self.grid.move_to_empty(agent)
            self.schedule.add(agent)

            id += 1
            if id > num_agents:
                break

    def step(self):
        self.datacollector.collect(self)
        self.schedule.step()
        


GRID_SIZE = 200
MAX_ITERATIONS = 100
THRESHOLD = 0.6
EMPTY_CELLS = 0.3

model = SegregationModel(GRID_SIZE, GRID_SIZE, EMPTY_CELLS, THRESHOLD)

for i in range(MAX_ITERATIONS):
    model.step()


all_grid = model.datacollector.get_model_vars_dataframe() # Arreglo de matrices

fig, axis = plt.subplots(figsize= (5, 5))
axis.set_xticks([])
axis.set_yticks([])
patch = plt.imshow(all_grid.iloc[0][0], cmap=plt.cm.binary)


def animate(i):
    patch.set_data(all_grid.iloc[i][0])
anim = animation.FuncAnimation(fig, animate, frames = MAX_ITERATIONS)



plt.show()