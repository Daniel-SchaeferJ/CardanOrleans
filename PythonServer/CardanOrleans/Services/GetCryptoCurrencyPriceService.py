from pycoingecko import CoinGeckoAPI


def GetAdaPrice():
    coin_gecko_api_client = CoinGeckoAPI()
    return coin_gecko_api_client.get_price(ids="cardano", vs_currencies='usd')
