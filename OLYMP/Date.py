from datetime import date

d0 = date(1956, 11, 1)
d1 = date(2048, 4, 30)
delta = d1 - d0
print(delta.days)
P = int(input())
sum = 0
if 1 <= delta.days < 60000:
    if 0 <= P:
        if P <= 5000:
            for n in range(0,delta.days+1):
                sum += P
                P += 1
                print(P,sum)
print(sum)
