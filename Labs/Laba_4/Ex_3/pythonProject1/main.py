import tkinter
from tkinter import *


def import_data():
    try:
        x = fileInput.readline()
        y = fileInput.readline()
        x = int(x)
        y = int(y)

        Ent1.delete(0, tkinter.END)
        Ent1.insert(0, str(x))
        Ent2.delete(0, tkinter.END)
        Ent2.insert(0, str(y))

        fileLog.write("Data import\n")
    except ValueError:
        print("В файлі якась лажа")
        LbResult.config(text="ERROR")
        fileLog.write(f"File import crab ERROR")


def calculate_data():
    x = Ent1.get()
    y = Ent2.get()
    try:
        if RBVar.get() == 1:
            LbResult.config(text=f"{x} + {y} Result: {int(x)+int(y)}")
            fileLog.write(f"Calculated {x} + {y}\n")
        elif RBVar.get() == 2:
            LbResult.config(text=f"{x} - {y} Result: {int(x)-int(y)}")
            fileLog.write(f"Calculated {x} - {y}\n")
        elif RBVar.get() == 3:
            LbResult.config(text=f"{x} * {y} Result: {int(x)*int(y)}")
            fileLog.write(f"Calculated {x} * {y}\n")
        elif RBVar.get() == 4:
            LbResult.config(text=f"{x} / {y} Result: {int(x)/int(y)}")
            fileLog.write(f"Calculated {x} / {y}\n")
        if RBVar.get() == 5:
            result = 1
            for i in range(1, int(y)+1):
                result *= int(x)
            LbResult.config(text=f"{x} ^ {y} Result: {result}")
            fileLog.write(f"Calculated {x} ^ {y}\n")
    except ZeroDivisionError:
        print("Ділення на 0 заборонено")
        LbResult.config(text="ERROR")
        fileLog.write(f"ZeroDivisionERROR")
    except ValueError:
        print("Воу, ну це ж не числа")
        LbResult.config(text="ERROR")
        fileLog.write(f"ValueERROR")
    except:
        print("Взагалі непонятна помилка")
        LbResult.config(text="ERROR")
        fileLog.write(f"UndefineERROR")

def export_data():
    line = LbResult.cget("text")
    fileOutput.write(line + "\n")
    fileLog.write(f"Data export")

if __name__ == '__main__':
    fileInput = open("InputData.txt", "r")
    fileOutput = open("OutputData.txt", "w")
    fileLog = open("SessionLog.txt", "w")

    window = Tk()
    window.geometry = "500x500"

    RBVar = IntVar()
    RBVar.set(1)

    fr1 = Frame(window)
    fr1.pack()
    Lb1 = Label(fr1, text="First number", width=50)
    Lb1.pack(side=tkinter.LEFT, padx=10)
    Lb2 = Label(fr1, text="Second number", width=50)
    Lb2.pack(side=tkinter.RIGHT, padx=10)

    fr2 = Frame(window)
    fr2.pack()
    Ent1 = Entry(fr2, width=50)
    Ent1.pack(side=tkinter.LEFT, padx=10)
    Ent1.insert(0, "0")
    Ent2 = Entry(fr2, width=50)
    Ent2.pack(side=tkinter.RIGHT, padx=10)
    Ent2.insert(0, "0")

    RB1 = Radiobutton(window, text="+", variable=RBVar, value=1)
    RB1.pack()
    RB2 = Radiobutton(window, text="-", variable=RBVar, value=2)
    RB2.pack()
    RB3 = Radiobutton(window, text="*", variable=RBVar, value=3)
    RB3.pack()
    RB4 = Radiobutton(window, text="/", variable=RBVar, value=4)
    RB4.pack()
    RB5 = Radiobutton(window, text="^", variable=RBVar, value=5)
    RB5.pack()

    BTImport = Button(window, width=50, text="Import data", command=import_data)
    BTImport.pack(pady=5)
    BTCalc = Button(window, width=50, text="Calculate", command=calculate_data)
    BTCalc.pack(pady=5)
    BTExport = Button(window, width=50, text="Export data", command=export_data)
    BTExport.pack(pady=5)

    LbResult = Label(window, width=50, text="Result:")
    LbResult.pack(pady=5)

    window.mainloop()
    fileInput.close()
    fileOutput.close()
    fileLog.close()