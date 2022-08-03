from pycoingecko import CoinGeckoAPI


class GetCryptoCurrencyPriceService:

    def GetAdaPrice(self):
        coin_gecko_api_client = CoinGeckoAPI()
        return coin_gecko_api_client.get_price(ids="cardano", vs_currencies='usd')
