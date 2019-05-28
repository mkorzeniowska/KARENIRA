import math
from operator import itemgetter
from collections import Counter

def read_data(filename):
    text_file = open(filename, 'r')
    list = []
    for line in text_file:
        if line.split():
            list.append([int(x) for x in line.split(',')])
    text_file.close()
    return list

train = read_data('train.txt')
test = read_data('test.txt')


def distance(x1,y1,x2,y2):
    return math.sqrt(((x1 - x2) ** 2) + ((y1 - y2) **2))


def calculate_distances(point, train):
    distances = []
    for p in train:
        d = distance(point[0], point[1], p[0], p[1])
        distances.append((p, d))
    return distances

def predict(point, train, k=3):
    distances = calculate_distances(point, train)
    neighbors = []
    distances.sort(key=itemgetter(1))
    for x in range(k):
        neighbors.append(distances[x][0])
        class_count = Counter()
        class_count[neighbors[x][-1]] += 1
        label = class_count.most_common(1)[0][0]
    return label

results = []
for point in test:
    results.append(predict(point, read_data('train.txt'), k=3))


def write_results(test_points, results):
    with open('results.txt', 'w') as file:
        for x in range(len(test_points)):
            buff = f"{test_points[x]} {results[x]} \n"
            file.write(buff)
    file.close()


write_results(test, results)