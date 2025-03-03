def findResult():
    while True:
        n = int(input("Enter amount of elements in range: "))
        if n <= 0:
            print("Inout can not be negative or equal 0 \n Try again")
        else:
            break

    print("Enter n numbers: ")
    odd = 0
    even = 0
    for i in range(1, n + 1):
        number = int(input())
        if i % 2 == 0:
            even += number
        else:
            odd += number

    return even - odd

if __name__ == '__main__':
    print(findResult())

