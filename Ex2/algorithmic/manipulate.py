import matplotlib.pyplot as plt
import numpy as np


def enter_numbers() -> list:
    numbers = []
    input_num = 0
    while not input_num == -1:
        input_num = input("Enter numbers until -1").strip()
        try:
            input_num = float(input_num)
            if input_num != -1:
                numbers.append(input_num)
        except:
            print("Only Numbers")
    return numbers


def manipulate():
    numbers = enter_numbers()
    sum = 0
    count_positive_numbers = 0
    count_numbers = 0
    for num in numbers:
        if num > 0:
            count_positive_numbers += 1
        sum += num
        count_numbers += 1
    average = sum / count_numbers
    show_point_graph(numbers)
    return average, count_positive_numbers, sorted(numbers)


def show_point_graph(numbers: list):
    ypoints = numbers
    plt.plot(ypoints)
    plt.show()
