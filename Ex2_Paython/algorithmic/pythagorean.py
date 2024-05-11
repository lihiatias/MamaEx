
def pythagorean_triplet_by_sum(input_sum:int) :
    options = []
    for a in range(1, input_sum):
        for b in range(a, input_sum):
            c = input_sum - (a+b)
            if c < b:
                break
            if a * a + b * b == c * c:
                options.append((a, b, c))
    return options