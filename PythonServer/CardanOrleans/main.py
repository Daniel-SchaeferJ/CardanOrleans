from flask import Flask

app = Flask(__name__)

#Register all endpoints here
import CardanOrleans.Handlers.CryptoPriceHandler

if __name__ == '__main__':
    app.run(host='localhost', port=5000, debug=True)
