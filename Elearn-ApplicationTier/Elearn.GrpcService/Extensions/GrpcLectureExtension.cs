using Elearn.Shared.Dtos;
using Elearn.Shared.Models;
using ElearnGrpc;

namespace Elearn.GrpcService.Extensions;

public static class  GrpcLectureExtension
{
    public static LectureModel AsGrpcModel(this Lecture lecture)
    {
        return new LectureModel
        {
            Id = lecture.Id,
            Url = lecture.Url,
            Image = lecture.Image,
            Title = lecture.Title,
            Body = lecture.Body,
            Teacher = GrpcTeacherExtension.AsGrpcModel(lecture.Author),
            Date = GrpcDateExtension.AsGrpcModel(lecture.DateCreated)
        };
    }

    public static Lecture AsBase(this LectureModel lectureModel)
    {
        return new Lecture
        {
            Id = lectureModel.Id,
            Url = lectureModel.Url,
            Image = lectureModel.Image,
            Title = lectureModel.Title,
            Body = lectureModel.Body,
            Author = GrpcTeacherExtension.AsBase(lectureModel.Teacher),
            DateCreated = GrpcDateExtension.AsBase(lectureModel.Date)
        };
    }
}

