from __main__ import app
from flask import jsonify

from CardanOrleans.Services.GetCryptoCurrencyPriceService import GetAdaPrice


@app.route('/get-current-price-of-ada')
@app.route('/')
def get_current_price_of_ada():
    price = jsonify({'price': GetAdaPrice()})
    return price
