import tkinter as tk
from tkinter import messagebox

class Transport:
    def __init__(self, kind, speed, year):
        self.kind = kind
        self.speed = speed
        self.year = year

    def cost(self):
        return (self.speed * self.year) / 100

    def update(self):
        self.year -= 5

    def info(self):
        return f"Вид: {self.kind}, Рік випуску: {self.year}, Вартість: {self.cost():.2f}"

class Airplane(Transport):
    def __init__(self, kind, speed, year, altitude):
        super().__init__(kind, speed, year)
        self.altitude = altitude

    def cost(self):
        return self.speed * self.year

    def update(self):
        self.year -= 3

    def info(self):
        return (f"Вид: {self.kind}, Рік випуску: {self.year}, Вартість: {self.cost():.2f},"
                f"Висота: {self.altitude}")


class Ship(Transport):
    def __init__(self, kind, speed, year, port):
        super().__init__(kind, speed, year)
        self.port = port

    def cost(self):
        return (self.speed * self.year) / 10

    def info(self):
        return (f"Вид: {self.kind}, Рік випуску: {self.year}, Вартість: {self.cost():.2f}, "
                f"Порт: {self.port}")


def create_transport():
    kind = kind_entry.get()
    speed = int(speed_entry.get())
    year = int(year_entry.get())
    global vehicle
    vehicle = Transport(kind, speed, year)
    messagebox.showinfo("Інформація про транспорт", vehicle.info())

def update_transport():
    if vehicle:
        vehicle.update()
        messagebox.showinfo("Оновлена інформація", vehicle.info())

def create_airplane():
    kind = kind_entry.get()
    speed = int(speed_entry.get())
    year = int(year_entry.get())
    altitude = int(altitude_entry.get())
    global airplane
    airplane = Airplane(kind, speed, year, altitude)
    messagebox.showinfo("Інформація про літак", airplane.info())

def update_airplane():
    if airplane:
        airplane.update()
        messagebox.showinfo("Оновлена інформація", airplane.info())

def create_ship():
    kind = kind_entry.get()
    speed = int(speed_entry.get())
    year = int(year_entry.get())
    port = port_entry.get()
    global ship
    ship = Ship(kind, speed, year, port)
    messagebox.showinfo("Інформація про корабель", ship.info())

def update_ship():
    if ship:
        ship.update()
        messagebox.showinfo("Оновлена інформація", ship.info())

window = tk.Tk()
window.title("Транспорт")

frame = tk.Frame(window)
frame.pack(padx=10, pady=10)

tk.Label(frame, text="Вид транспорту:").pack()
kind_entry = tk.Entry(frame)
kind_entry.pack()

tk.Label(frame, text="Швидкість (км/год):").pack()
speed_entry = tk.Entry(frame)
speed_entry.pack()

tk.Label(frame, text="Рік випуску:").pack()
year_entry = tk.Entry(frame)
year_entry.pack()

tk.Label(frame, text="Висота (для літака):").pack()
altitude_entry = tk.Entry(frame)
altitude_entry.pack()

tk.Label(frame, text="Порт приписки (для корабля):").pack()
port_entry = tk.Entry(frame)
port_entry.pack()

button_frame = tk.Frame(frame)
button_frame.pack(pady=5)
tk.Button(button_frame, text="Створити транспорт", command=create_transport).pack(side=tk.LEFT, padx=5)
tk.Button(button_frame, text="Update", command=update_transport).pack(side=tk.LEFT, padx=5)

button_frame2 = tk.Frame(frame)
button_frame2.pack(pady=5)
tk.Button(button_frame2, text="Створити літак", command=create_airplane).pack(side=tk.LEFT, padx=5)
tk.Button(button_frame2, text="Update", command=update_airplane).pack(side=tk.LEFT, padx=5)

button_frame3 = tk.Frame(frame)
button_frame3.pack(pady=5)
tk.Button(button_frame3, text="Створити корабель", command=create_ship).pack(side=tk.LEFT, padx=5)
tk.Button(button_frame3, text="Update", command=update_ship).pack(side=tk.LEFT, padx=5)

vehicle = None
airplane = None
ship = None

window.mainloop()