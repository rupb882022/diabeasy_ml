﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace Diabeasy_ml
{
    public partial class MLModel
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(new []{new InputOutputColumnPair(@"weekday", @"weekday"),new InputOutputColumnPair(@"dayTime", @"dayTime")})      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"blood_sugar_level", @"blood_sugar_level"),new InputOutputColumnPair(@"value_of_ingection", @"value_of_ingection"),new InputOutputColumnPair(@"totalCarbs", @"totalCarbs")}))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"weekday",@"dayTime",@"blood_sugar_level",@"value_of_ingection",@"totalCarbs"}))      
                                    .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))      
                                    .Append(mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression(l1Regularization:0.819570942541211F,l2Regularization:0.0369158658318598F,labelColumnName:@"good",featureColumnName:@"Features"));

            return pipeline;
        }
    }
}
