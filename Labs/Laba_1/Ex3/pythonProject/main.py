def print_hi(name):
    print(f'Hi, {name}')

class Figure:
    def __init__(self, name, x, y, color):
        self.name = name
        self.x = x
        self.y = y
        self.color = color

def enterFigure(message, whiteFig, blackFig, figureName, color):
    test: bool = True
    while(test):
        x, y = map(int, input(message).split())

        test = False
        for i in whiteFig:
            if (i.x == x and i.y == y) or (x < 1 or x > 8 or y < 1 or y > 8):
                test = True
                print("Wrong input\n Try again")
                break
        if not(test):
            for i in blackFig:
                if (i.x == x and i.y == y) or (x < 1 or x > 8 or y < 1 or y > 8):
                    test = True
                    print("Wrong input\n Try again")
                    break

    if (color == "W"):
        whiteFig.append(Figure(figureName, x, y, color))
        return whiteFig
    else:
        blackFig.append(Figure(figureName, x, y, color))
        return blackFig

def searchAsRook(x, y, colorToSearch, whiteFig, blackFig):
    result = set()
    # if(colorToSearch == "W"):
    #     for i in whiteFig:
    #         if(x == i.x or y == i.y):
    #             result.append(i)
    # elif (colorToSearch == "B"):
    #     for i in blackFig:
    #         if (x == i.x or y == i.y):
    #             result.append(i)

    if (colorToSearch == "W"):
        for i in range(1, 8):
            for j in whiteFig:
                if j.x == i and j.y == y and j.color == colorToSearch:
                    result.add(j)
                elif j.x == x and j.y == i and j.color == colorToSearch:
                    result.add(j)
    elif (colorToSearch == "B"):
        for i in range(1, 8):
            for j in blackFig:
                if j.x == i and j.y == y and j.color == colorToSearch:
                    result.add(j)
                elif j.x == x and j.y == i and j.color == colorToSearch:
                    result.add(j)

    return result


def searchAsBishop(x, y, colorToSearch, whiteFig, blackFig):
    result = set()
    # if (colorToSearch == "W"):
    #     for i in whiteFig:
    #         if (abs(x - i.x) == abs(y - i.y)):
    #             result.append(i)
    # elif (colorToSearch == "B"):
    #     for i in blackFig:
    #         if (abs(x - i.x) == abs(y - i.y)):
    #             result.append(i)

    if colorToSearch == "W":
        for i in range(1, 8):
            for j in whiteFig:
                if j.x == x+i and j.y == y+i and j.color == colorToSearch:
                    result.add(j)
                elif j.x == x+i and j.y == y-i and j.color == colorToSearch:
                    result.add(j)
                elif j.x == x-i and j.y == y-i and j.color == colorToSearch:
                    result.add(j)
                elif j.x == x-i and j.y == y+i and j.color == colorToSearch:
                    result.add(j)
    elif colorToSearch == "B":
        for i in range(1, 8):
            for j in blackFig:
                if j.x == x + i and j.y == y + i and j.color == colorToSearch:
                    result.add(j)
                elif j.x == x + i and j.y == y - i and j.color == colorToSearch:
                    result.add(j)
                elif j.x == x - i and j.y == y - i and j.color == colorToSearch:
                    result.add(j)
                elif j.x == x - i and j.y == y + i and j.color == colorToSearch:
                    result.add(j)

    return result


def searchForFig(figure, colorToSearch, whiteFig, blackFig):
    result = []
    if figure.name == "rook":
        result = searchAsRook(figure.x, figure.y, colorToSearch, whiteFig, blackFig)
    elif figure.name == "bishop":
        result = searchAsBishop(figure.x, figure.y, colorToSearch, whiteFig, blackFig)

    return result


def attack(figure, whiteFig, blackFig):
    active = False
    attacked = []
    if figure.color == "W":
        attacked = searchForFig(figure, "B", whiteFig, blackFig)
    elif figure.color == "B":
        attacked = searchForFig(figure, "W", whiteFig, blackFig)

    for i in attacked:
        print(figure.name, "(", figure.x, ";", figure.y, ") attack ", i.name, "(", i.x, ";", i.y, ")")
        active = True

    return active


def defense(figure, whiteFig, blackFig):
    active = False
    defensed = []
    if figure.color == "W":
        defensed = searchForFig(figure, "W", whiteFig, blackFig)
        attacked = []
        for i in blackFig:
            attacked = searchForFig(i, "W", whiteFig, blackFig)
            for j in defensed:
                for l in attacked:
                    if j == l:
                        print(figure.name, "(", figure.x, ";", figure.y, ") defense ", j.name, "(", j.x, ";", j.y, ")")
                        active = True

    elif figure.color == "B":
        defensed = searchForFig(figure, "B", whiteFig, blackFig)
        attacked = []
        for i in whiteFig:
            attacked = searchForFig(i, "B", whiteFig, blackFig)
            for j in defensed:
                for l in attacked:
                    if j == l:
                        print(figure.name, "(", figure.x, ";", figure.y, ") defense ", j.name, "(", j.x, ";", j.y, ")")
                        active = True

    return active




if __name__ == '__main__':
    whiteFig = []
    blackFig = []

    whiteFig = enterFigure("Enter coordinates of the first Rook: ", whiteFig, blackFig, "rook", "W")
    whiteFig = enterFigure("Enter coordinates of the second Rook: ", whiteFig, blackFig, "rook", "W")
    blackFig = enterFigure("Enter coordinates of the first Bishop: ", whiteFig, blackFig, "bishop", "B")
    blackFig = enterFigure("Enter coordinates of the second Bishop: ", whiteFig, blackFig, "bishop", "B")

    for i in whiteFig:
        if not(attack(i, whiteFig, blackFig)) and not(defense(i, whiteFig, blackFig)):
            print(i.name, "(", i.x, ";", i.y, ") simple move")

    for i in blackFig:
        if not (attack(i, whiteFig, blackFig)) and not (defense(i, whiteFig, blackFig)):
            print(i.name, "(", i.x, ";", i.y, ") simple move")

