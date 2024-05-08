
def enter_numbers()-> list:
    numbers =[]
    input_num = 0
    while not input_num == -1:
        input_num = input("Enter numbers until -1").strip()
        try:
            input_num = float(input_num)
            numbers.append(input_num)
        except:
            print("Only Numbers")
    return numbers

def manipulate():
    numbers = enter_numbers()
    sum = 0
    count_positive_numbers = 0
    count_numbers =0
    for num in numbers:
        if num> 0:
            count_positive_numbers +=1
        sum +=num
        count_numbers+=1

    average = sum/count_numbers

    print (f"The numbers average :{average}")
    print (f"The count of positive numbers : {count_positive_numbers}")
    print(sorted(numbers))