X = ["a", "b", "c", "d", "e", "f", "g", "h", "i"]
Y = [ 0,   1,   1,    0,   1,   2,   2,   0,   1]
keydict = dict(zip(X, Y))
X.sort(key=keydict.get)
print(X)