import random


def find_AVR_for_each(arr, hight, width):
    result = []
    sum = 0

    for i in range(0, width):
        sum = 0
        for j in range(0, hight):
            sum += arr[j][i]
        result.append(sum / hight)

    return result


def find_AVR_for_all(arr, hight):
    result = 0
    for i in arr:
        result += i

    result /= width

    return result


if __name__ == '__main__':
    hight = 2
    width = 4
    arr = []
    for i in range(0, hight):
        temp_arr = []
        for j in range(0, width):
            temp_arr.append(0)
        arr.append(temp_arr)

    for i in range(0, hight):
        for j in range(0, width):
            arr[i][j] = random.randint(1, 10)

    for i in arr:
        print(i)

    result = find_AVR_for_each(arr, hight, width)
    print(result)

    print(find_AVR_for_all(result, hight))
