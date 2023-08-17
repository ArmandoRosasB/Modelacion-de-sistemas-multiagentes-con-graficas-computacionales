from mesa import Agent, Model
from mesa.time import RandomActivation

# The below is needed for both notebooks and scripts
import matplotlib.pyplot as plt

class MoneyAgent(Agent):
    def __init__(self, id, model):
        super().__init__(id, model) # Iniclializamos el contstructor de Agente
        self.wealth = 1

    def step(self):
        if self.wealth == 0: # Si no tengo dinero, no puedo hacer nada
            return

        other_agent = self.random.choice(self.model.schedule.agents) # Seleccionamos un agente aleatorio
        other_agent.wealth += 1 # Le damos dinero a otro agente (Una compra, transaccion, etc)
        self.wealth -= 1

class MoneyModel(Model):
    def __init__(self, num_agents):
        self.schedule = RandomActivation(self)

        for i in range(num_agents):
            agent = MoneyAgent(i, self)
            self.schedule.add(agent)

    def step(self):
        self.schedule.step()

NUM_AGENTS = 10
MAX_ITERATIONS = 10

model = MoneyModel(NUM_AGENTS)

for i in range(MAX_ITERATIONS):
    model.step()


agent_wealth = [agent.wealth for agent in model.schedule.agents]
plt.hist(agent_wealth)

plt.show()