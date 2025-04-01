import tkinter as tk
from tkinter import messagebox
from tkinter.scrolledtext import ScrolledText
from abc import ABC, abstractmethod

class Employee:
    def __init__(self, firstName, secondName, age, amountOfWorkingHours):
        self.firstName = firstName
        self.secondName = secondName
        self.age = age
        self.amountOfWorkingHours = amountOfWorkingHours

    @abstractmethod
    def show_info(self):
        return f"Name: {self.firstName} {self.secondName}\nAge: {self.age}\nAmount of working hours: {self.amountOfWorkingHours}"

    @abstractmethod
    def is_working(self):
        pass

class Worker(Employee):
    def __init__(self, firstName, secondName, age, amountOfWorkingHours, experience):
        super().__init__(firstName, secondName, age, amountOfWorkingHours)
        self.experience = experience

    def show_info(self):
        return super().show_info() + "Experience: {self.experience}"

    def is_working(self):
        print("Working veeery hard right now")

    def add_experience(self):
        self.experience += 1

class TooSmallSalary(Exception):
    def __init__(self, message):
        super().__init__(message)
class Servant(Employee):
    def __init__(self, firstName, secondName, age, amountOfWorkingHours, salary):
        super().__init__(firstName, secondName, age, amountOfWorkingHours)
        self.salary = salary

    def show_info(self):
        return super().show_info() + "Salary: {self.salary}"

    def is_working(self):
        print("Working not very hard right now")

    def decrease_salary(self, number):
        try:
            if number <= 0:
                raise ValueError("Input number cannot be negative or 0!!!")
            if self.salary - number < 0:
                raise TooSmallSalary("The salary of servant is too small!!")
            else:
                self.salary -= number
        except ValueError as e:
            print(e)
        except TooSmallSalary as e:
            print(e)

def find_with_the_same_hours(list):
    list_c = list
    result = []

    i = 0
    while i < len(list_c):
        arr = []
        j = i + 1
        while j < len(list_c):
            if list[i].amountOfWorkingHours == list_c[j].amountOfWorkingHours:
                arr.append(list_c[j])
                del list_c[j]
                j = j - 1
            j = j + 1
        arr.append(list_c[i])
        del list_c[i]
        i = i - 1
        if len(arr) != 0:
            result.append(arr)
        i = i + 1

    return result

employees = []

class EmployeeManagerGUI:
    def __init__(self, root):
        self.root = root
        self.root.title("Employee Manager")
        self.root.geometry("600x800")

        self.current_worker = 0
        self.current_servant = 0

        self.entry_workers = tk.Entry(root)
        self.entry_servants = tk.Entry(root)

        lbl_workers = tk.Label(root, text="Number of Workers:")
        lbl_servants = tk.Label(root, text="Number of Servants:")

        lbl_workers.pack()
        self.entry_workers.pack()
        lbl_servants.pack()
        self.entry_servants.pack()

        btn_add_worker = tk.Button(root, text="Add Workers", command=lambda: self.add_worker())
        btn_add_servant = tk.Button(root, text="Add Servants", command=lambda: self.add_servant())
        btn_show_all = tk.Button(root, text="Show All Employees", command=self.show_all_employees)
        btn_search_schedule = tk.Button(root, text="Search by Schedule", command=self.search_by_schedule)
        btn_add_experience = tk.Button(root, text="Add Experience", command=self.add_experience)
        btn_decrease_salary = tk.Button(root, text="Decrease Salary", command=self.decrease_salary)

        btn_add_worker.pack()
        btn_add_servant.pack()
        btn_show_all.pack()
        btn_search_schedule.pack()
        btn_add_experience.pack()
        btn_decrease_salary.pack()

    def add_worker(self):
        if self.current_worker < int(self.entry_workers.get()):
            self.input_window('worker')
        else:
            messagebox.showinfo("Info", "All Workers added")

    def add_servant(self):
        if self.current_servant < int(self.entry_servants.get()):
            self.input_window('servant')
        else:
            messagebox.showinfo("Info", "All Servants added")

    def input_window(self, emp_type):
        input_win = tk.Toplevel(self.root)
        input_win.title("Add Employee")

        lbl_first_name = tk.Label(input_win, text="First Name:")
        lbl_second_name = tk.Label(input_win, text="Second Name:")
        lbl_age = tk.Label(input_win, text="Age:")
        lbl_hours = tk.Label(input_win, text="Working Hours:")
        lbl_extra = tk.Label(input_win, text="Experience:" if emp_type == 'worker' else "Salary:")

        entry_first_name = tk.Entry(input_win)
        entry_second_name = tk.Entry(input_win)
        entry_age = tk.Entry(input_win)
        entry_hours = tk.Entry(input_win)
        entry_extra = tk.Entry(input_win)

        lbl_first_name.pack()
        entry_first_name.pack()
        lbl_second_name.pack()
        entry_second_name.pack()
        lbl_age.pack()
        entry_age.pack()
        lbl_hours.pack()
        entry_hours.pack()
        lbl_extra.pack()
        entry_extra.pack()

        def save_employee():
            first_name = entry_first_name.get()
            second_name = entry_second_name.get()
            age = int(entry_age.get())
            hours = int(entry_hours.get())
            extra = int(entry_extra.get())

            if emp_type == 'worker':
                employees.append(Worker(first_name, second_name, age, hours, extra))
                self.current_worker += 1
            else:
                employees.append(Servant(first_name, second_name, age, hours, extra))
                self.current_servant += 1

            input_win.destroy()

        btn_save = tk.Button(input_win, text="Save", command=save_employee)
        btn_save.pack()

    def show_all_employees(self):
        output_win = tk.Toplevel(self.root)
        output_win.title("All Employees")
        text_area = ScrolledText(output_win, width=60, height=30)
        text_area.pack()
        result = "\n".join([emp.show_info() for emp in employees])
        text_area.insert(tk.END, result)

    def search_by_schedule(self):
        hours = int(tk.simpledialog.askstring("Search", "Enter working hours:"))
        result = "\n".join([emp.show_info() for emp in employees if emp.amountOfWorkingHours == hours])
        messagebox.showinfo("Search Result", result)

    def add_experience(self):
        for emp in employees:
            if isinstance(emp, Worker):
                emp.add_experience()
        messagebox.showinfo("Success", "Experience increased for all workers.")

    def decrease_salary(self):
        amount = int(tk.simpledialog.askstring("Decrease Salary", "Enter amount:"))
        for emp in employees:
            if isinstance(emp, Servant):
                emp.decrease_salary(amount)
        messagebox.showinfo("Success", "Salary decreased for all servants.")

root = tk.Tk()
app = EmployeeManagerGUI(root)
root.mainloop()
