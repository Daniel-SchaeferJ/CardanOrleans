import requests

from flask import Flask

from CardanOrleans.Handlers.CryptoPriceHandler import CryptoPriceHandler

app = Flask(__name__)


@app.route('/get-current-price-of-ada')
def get_current_price_of_ada():
    price_handler = CryptoPriceHandler
    return price_handler.get_current_price_of_ada(price_handler)


if __name__ == '__main__':
    app.run(host='localhost', port=5000, debug=True)
