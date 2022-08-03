from flask import jsonify, Response, request, json

from CardanOrleans.Services.GetCryptoCurrencyPriceService import GetCryptoCurrencyPriceService


class CryptoPriceHandler:
    def get_current_price_of_ada(self):
        price = jsonify({'price': GetCryptoCurrencyPriceService.GetAdaPrice(self)})
        return price
