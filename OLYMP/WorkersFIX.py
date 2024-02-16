file_path_i = "C:\\Users\\Admin\\Downloads\\Kompania_KhKhKh\\Компания ХХХ\\input_s1_01.txt"
file_path_o = "C:\\Users\\Admin\\Downloads\\Kompania_KhKhKh\\Компания ХХХ\\output_s1_01.txt"

data_dict = {}
stop_word = "END"
end_encountered = False
output_strings = ""

with open(file_path_i, 'r') as file:
    for line in file:
        if line.strip() == stop_word:
            end_encountered = True
            break
        key_value = line.strip().split(' ')
        key = key_value[0]
        value = key_value[1] + " " + key_value[2] if len(key_value) > 1 else 'Unknown Name'
        data_dict[key] = value

    if end_encountered:
        print("База данных: " + str(data_dict))
        boss = file.readline().strip()
        print("Босс:" + boss)

        if boss in data_dict.values():
            key_to_remove = next((k for k, v in data_dict.items() if v == boss), None)
            del data_dict[key_to_remove]
        else:
            for key, value in data_dict.items():
                if value == boss:
                    del data_dict[key]
                    break

sorted_data_dict = dict(sorted(data_dict.items(), key=lambda x: x[0]))
print("Список работников:")
for key, value in sorted_data_dict.items():
        output_strings += f"{key}: {value}\n"
print(output_strings)
