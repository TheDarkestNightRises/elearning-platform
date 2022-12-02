using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class GrpcDeleteOwnQuestion
{
    public static DeleteOwnQuestion AsGrpcModel(this DeleteOwnQuestion deleteOwnQuestion)
    {
        return new DeleteOwnQuestion()
        {

        };
    }
}