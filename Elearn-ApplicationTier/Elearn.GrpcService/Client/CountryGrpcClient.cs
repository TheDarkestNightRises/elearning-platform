using Elearn.Application.ServiceContracts;
using Elearn.GrpcService.Extensions;
using Elearn.Shared.Models;
using ElearnGrpc;
using Grpc.Core;

namespace Elearn.GrpcService.Client;

public class CountryGrpcClient : ICountryService
{
    private CountryService.CountryServiceClient _countryClient;

    public CountryGrpcClient()
    {
        var _grpcChannel = new Channel("localhost:8843", ChannelCredentials.Insecure);
        _countryClient = new CountryService.CountryServiceClient(_grpcChannel);
    }

    public async Task<List<Country>> GetAllCountriesAsync()
    {
        List<Country> countries = new List<Country>();
        using (var call = _countryClient.GetCountries(new CountryRequest()))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentCountry = call.ResponseStream.Current;
                countries.Add(currentCountry.AsBase());
            }
        }
        return countries;
    }

    public async Task<Country> GetCountryByIdAsync(long id)
    {
        var countryId = new CountryId() { Id = id };
        var countryModel = await _countryClient.GetCountryByIdAsync(countryId);
        return countryModel.AsBase();
    }
}