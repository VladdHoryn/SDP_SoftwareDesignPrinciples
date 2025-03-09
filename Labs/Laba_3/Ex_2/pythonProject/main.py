import tkinter
from tkinter import *


def find_com():
    line = text_box.get()
    result = ""

    pozition = line.find(".com")
    while pozition != -1:
        line = line.replace(".com", "", 1)
        result += ".com "
        pozition = line.find(".com")

    label.config(text=f"{result}")


def find_com_quan():
    line = text_box.get()
    result = 0

    pozition = line.find(".com")
    while pozition != -1:
        line = line.replace(".com", "", 1)
        result += 1
        pozition = line.find(".com")

    label.config(text=f"{result}")


def delete_elem():
    line = text_box.get()
    line_to_del = text_box_delete_el.get()

    pozition = line.find(line_to_del)
    while pozition != -1:
        line = line.replace(line_to_del, "", 1)
        pozition = line.find(line_to_del)

    text_box.delete(0, tkinter.END)
    text_box.insert(0, line)
    label.config(text=f"{line}")


def replace_elem():
    line = text_box.get()
    line_to_replace = text_box_find_elem.get()
    line_replace_by = text_box_elem_to_replace.get()

    pozition = line.find(line_to_replace)
    while pozition != -1:
        line = line.replace(line_to_replace, line_replace_by, 1)
        pozition = line.find(line_to_replace)

    text_box.delete(0, tkinter.END)
    text_box.insert(0, line)
    label.config(text=f"{line}")


if __name__ == '__main__':
    window = Tk()
    window.geometry("500x500")
    window.title("Tkinter program")

    # Основне поле введення
    Label(window, text="Введіть текст:").pack(pady=5)
    text_box = Entry(window, width=50)
    text_box.pack(pady=5)

    Label(window, text="Пошук '.com':").pack()
    btn_find = Button(window, text="Знайти .com", command=find_com)
    btn_find.pack(padx=5)
    btn_find_quan = Button(window, text="Кількість .com", command=find_com_quan)
    btn_find_quan.pack(padx=5)

    Label(window, text="Видалити елемент:").pack()
    text_box_delete_el = Entry(window, width=30)
    text_box_delete_el.pack(pady=2)
    btn_delete_el = Button(window, text="Видалити", command=delete_elem)
    btn_delete_el.pack(pady=2)

    Label(window, text="Замінити елемент:").pack()
    text_box_find_elem = Entry(window, width=30)
    text_box_find_elem.pack(pady=2)
    Label(window, text="На:").pack()
    text_box_elem_to_replace = Entry(window, width=30)
    text_box_elem_to_replace.pack(pady=2)
    btn_replace = Button(window, text="Замінити", command=replace_elem)
    btn_replace.pack(pady=5)

    # Результат
    label = Label(window, text="Результат:", font=("Arial", 12))
    label.pack(pady=10)

    window.mainloop()
