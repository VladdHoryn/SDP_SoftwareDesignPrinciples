import tkinter
from tkinter import *

def replace():
    line = text_box.get()
    line_first = text_box_first.get()
    line_second = text_box_second.get()

    if line_first == line_second:
        label_error.config(text="Words Cannot be same!!!")

    else:
        find = line.find(line_first)
        while find != -1:
            line = line.replace(line_first, line_second,  1)
            find = line.find(line_first)
            print(find)

        text_box.delete(0, tkinter.END)
        text_box.insert(0, line)


if __name__ == '__main__':
    window = Tk()
    window.geometry("500x500")

    text_box = Entry(window, width=50)
    text_box.pack()

    frame = Frame(window)
    frame.pack()

    label_first = Label(frame, text="First word")
    label_first.pack(side=tkinter.LEFT, padx=40)
    label_second = Label(frame, text="Second word")
    label_second.pack(side=tkinter.RIGHT, padx=40)

    frame2 = Frame(window)
    frame2.pack()

    text_box_first = Entry(frame2)
    text_box_first.pack(side=tkinter.LEFT, padx=10)
    text_box_second = Entry(frame2)
    text_box_second.pack(side=tkinter.RIGHT, padx=10)

    btn_first = Button(window, text="Replace", command=replace)
    btn_first.pack()

    label_error = Label(window, text="")
    label_error.pack()

    window.mainloop()


