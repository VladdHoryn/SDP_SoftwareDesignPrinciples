def find_AVR_for_each(arr, hight, width):
    result = []
    sum = 0

    for i in range(0, hight):
        sum = 0
        for j in range(0, width):
            sum += arr[i][j]
        result.append(sum / width)

    return result


def find_AVR_for_all(arr, hight):
    result = 0
    for i in arr:
        result += i;

    result /= hight

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
        print("Enter " + str(width) + " elements of array one by one: ")
        for j in range(0, width):
            arr[i][j] = int(input())

    result = find_AVR_for_each(arr, hight, width)
    print(result)

    print(find_AVR_for_all(result, hight))
