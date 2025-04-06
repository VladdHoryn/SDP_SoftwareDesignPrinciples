import tkinter as tk
from tkinter import messagebox

class Date:
    def __init__(self, year, month, day, hour, minute, second):
        self.year = int(year)
        self.month = int(month)
        self.day = int(day)
        self.hour = int(hour)
        self.minute = int(minute)
        self.second = int(second)
    def get_date(self):
        return f"{self.year} {self.month} {self.day} {self.hour} {self.minute} {self.second}"

    def to_seconds(self):
        seconds_in_minute = 60
        seconds_in_hour = 60 * seconds_in_minute  # 3600
        seconds_in_day = 24 * seconds_in_hour  # 86400
        seconds_in_month = 30 * seconds_in_day  # 2592000
        seconds_in_year = 365 * seconds_in_month

        result = (self.second + self.minute*seconds_in_minute + self.hour*seconds_in_hour + self.day*seconds_in_day +
                  self.month * seconds_in_month + self.year*seconds_in_year)
        return result

def get_date_from_GUI():
    start_date_str: str = start_date_entry.get() + ":" + start_time_entry.get()
    start_date_str = start_date_str[:2] + ":" + start_date_str[2:4] + ":" + start_date_str[4:]
    start_date_list = start_date_str.split(":")
    date_start: Date = Date(start_date_list[0], start_date_list[1], start_date_list[2], start_date_list[3],
                            start_date_list[4], start_date_list[5])

    end_date_str: str = end_date_entry.get() + ":" + end_time_entry.get()
    end_date_str = end_date_str[:2] + ":" + end_date_str[2:4] + ":" + end_date_str[4:]
    end_date_list = end_date_str.split(":")
    date_end: Date = Date(end_date_list[0], end_date_list[1], end_date_list[2], end_date_list[3],
                          end_date_list[4], end_date_list[5])

    return date_start, date_end

def get_price_from_GUI():
    price = float(cost_entry.get())
    price /= 100

    return price

def calculate():
    dates = get_date_from_GUI()
    date_start = dates[0]
    date_end = dates[1]

    call_duration = date_end.to_seconds() - date_start.to_seconds()
    call_cost = int(call_duration/60) * get_price_from_GUI()

    result_label.config(text=f"Call duration: {call_duration}\nCall cost: {call_cost}")




if __name__ == '__main__':
    root = tk.Tk()
    root.title("Розрахунок дзвінка")

    tk.Label(root, text="Дата початку (ДДММРРРР):").grid(row=0, column=0, sticky="e")
    start_date_entry = tk.Entry(root)
    start_date_entry.grid(row=0, column=1)

    tk.Label(root, text="Час початку (ГГ:ХХ:СС):").grid(row=1, column=0, sticky="e")
    start_time_entry = tk.Entry(root)
    start_time_entry.grid(row=1, column=1)

    tk.Label(root, text="Дата завершення (ДДММРРРР):").grid(row=2, column=0, sticky="e")
    end_date_entry = tk.Entry(root)
    end_date_entry.grid(row=2, column=1)

    tk.Label(root, text="Час завершення (ГГ:ХХ:СС):").grid(row=3, column=0, sticky="e")
    end_time_entry = tk.Entry(root)
    end_time_entry.grid(row=3, column=1)

    tk.Label(root, text="Вартість 1 хвилини (копійки):").grid(row=4, column=0, sticky="e")
    cost_entry = tk.Entry(root)
    cost_entry.grid(row=4, column=1)

    tk.Button(root, text="Розрахувати", command=calculate).grid(row=5, column=0, columnspan=2, pady=10)

    result_label = tk.Label(root, text="", font=("Arial", 12), fg="green")
    result_label.grid(row=6, column=0, columnspan=2)

    root.mainloop()
