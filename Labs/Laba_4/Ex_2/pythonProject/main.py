
if __name__ == '__main__':

    n = int(input("Enter amount of lines: "))

    f = open("TF_1.txt", "w")
    for i in range(n):
        s = input("Enter line: ")
        f.write(s + "\n")
    f.close()


    f = open("TF_1.txt", "r")
    list = []
    list = f.readlines()
    f.close()

    lengthList = [""] * 16

    words = []
    for i in list:
        words = i.split(" ")
        for j in words:
            if j[len(j)-1] == '\n':
                j = j[:-1]
            lengthList[len(j)-1] += j + " "

    f = open("TF_2.txt", "w")
    for i in range(1, len(lengthList)):
        f.write(str(i) + ": " + lengthList[i-1] + "\n")
    f.close()

    f = open("TF_2.txt", "r")
    for i in f.readlines():
        print(i)
