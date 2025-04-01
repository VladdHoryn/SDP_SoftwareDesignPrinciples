import tkinter as tk
from tkinter import messagebox


# Базовий клас
class Persona:
    def __init__(self, name="", age=0, gender=""):
        self.name = name
        self.age = age
        self.gender = gender

    def show(self):
        return f"Ім'я: {self.name}, Вік: {self.age}, Стать: {self.gender}"

    def work(self):
        return "Займається загальною діяльністю."

    def __del__(self):
        print("Лабораторна робота виконанна студентом 2 курсу Горином Владиславом Мирославовичом студента")


class Employee(Persona):
    def __init__(self, name="", age=0, gender="", position=""):
        super().__init__(name, age, gender)
        self.position = position

    def show(self):
        return super().show() + f", Посада: {self.position}"

    def work(self):
        return "Виконує службові обов'язки."


class Worker(Employee):
    def __init__(self, name="", age=0, gender="", position="", department=""):
        super().__init__(name, age, gender, position)
        self.department = department

    def show(self):
        return super().show() + f", Відділ: {self.department}"

    def work(self):
        return "Займається фізичною роботою."


class Engineer(Employee):
    def __init__(self, name="", age=0, gender="", position="", field=""):
        super().__init__(name, age, gender, position)
        self.field = field

    def show(self):
        return super().show() + f", Галузь: {self.field}"

    def work(self):
        return "Проектує та створює технічні рішення."


if __name__ == "__main__":
    root = tk.Tk()
    root.title("Ієрархія класів")
    root.geometry("400x300")

    label = tk.Label(root, text="Натисніть кнопку для відображення об'єкта:")
    label.pack()


    def show_info(obj):
        messagebox.showinfo("Інформація", obj.show() + "\n" + obj.work())


    button1 = tk.Button(root, text="Persona", command=lambda: show_info(Persona("Олександр", 25, "Чоловік")))
    button1.pack()

    button2 = tk.Button(root, text="Employee", command=lambda: show_info(Employee("Марія", 30, "Жінка", "Менеджер")))
    button2.pack()

    button3 = tk.Button(root, text="Worker",
                        command=lambda: show_info(Worker("Іван", 40, "Чоловік", "Робітник", "Виробництво")))
    button3.pack()

    button4 = tk.Button(root, text="Engineer",
                        command=lambda: show_info(Engineer("Андрій", 35, "Чоловік", "Інженер", "Будівництво")))
    button4.pack()

    root.mainloop()
