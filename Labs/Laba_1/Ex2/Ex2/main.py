import random
def Generete_R():
    return 1
    # return random.randint(0, 1)

def Generete_X_and_Y():
    x = random.uniform(-1, 3)
    y = random.uniform(-1, 3)
    return x, y

def FindResult(R, x, y):
    result = "No answer"
    if (abs(x) > R or abs(y) > R):
        result = "No"
    elif (x + R)*(x + R) + (y - R)*(y - R) < R*R or (x - R)*(x - R) + (y + R)*(y + R) < R*R:
        result = "No"
    elif (x + R) * (x + R) + (y - R) * (y - R) == R * R or (x - R) * (x - R) + (y + R) * (y + R) == R * R:
        result = "On the verge"
    elif x == R or y == R:
        result = "On the verge"
    else:
        result = "Yes"

    return result

def Write_answers():
    print("| № shot | shot coordinates |" + "result".center(14) + '|')
    for i in range(1, 10):
        R = Generete_R()
        (x, y) = Generete_X_and_Y()
        result = FindResult(R, x, y)
        print('|' + str(i).center(8) + '|' + ('(' + str(x) + ';' + str(y) + ')').center(18) + '|' + result.center(14) + '|')


if __name__ == '__main__':
    Write_answers()


