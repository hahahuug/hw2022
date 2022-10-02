import json
import pprint

class Hotel(object):
    def __init__(self, name, address, category, phone):
        self.name = name
        self.address = address
        self.category = category
        self.phone = phone

class Room(object):
    def __init__(self, hotel, room_number, category, price):
        self.hotel = hotel
        self.room_number = room_number
        self.category = category
        self.price = price

class Bed(object):
    def __init__(self, room, info, price):
        self.room = room
        self.info = info
        self.price = price

class Client(object):
    def __init__(self, name, gender, birth_date, phone):
        self.name = name
        self.gender = gender
        self.birth_date = birth_date
        self.phone = phone

class Booking(object):
    def __init__(self, client, arrival_date, staying_date, room, beds, summ):
        self.client = client
        self.arrival_date = arrival_date
        self.staying_date = staying_date
        self.room = room
        self.beds = beds
        self.summ = summ

class DataBase(object):
    def __init__(self, bookings):
        self.bookings = bookings


hotel1 = Hotel("Гранд хостел", "Казань", "**","+111111")
room1 = Room(hotel1, "12", "эконом", "1000")
bed1 = Bed(room1, "-","500")
bed2 = Bed(room1, "--","500")
client1 = Client("Kamil","M","01.01.2000","+2222222")

booking1 = Booking(client1,"10.09.2022", "11.09.2022",room1,[bed1,bed2],2000)

hotel2 = Hotel("Гранд палас", "Казань", "*****","+333333")
room2 = Room(hotel2, "100", "эконом", "5000")
bed = Bed(room2, "","5000")
client2 = Client("Misha","M","01.01.2000","+444444")

booking2 = Booking(client2,"10.09.2022", "11.09.2022",room2,[bed],10000)

data_base = DataBase([booking1, booking2])

r = json.dumps(data_base, default=lambda x: x.__dict__, ensure_ascii=False)
print(r)
