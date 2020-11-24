using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Wickers.Movie.Data.Model;

namespace Wickers.Movie.Data
{
    public class ParameterManager
    {
        public static DynamicParameters CreateParameters(List<ParameterModel> Parameters)
        {
            DynamicParameters parameters = new DynamicParameters();

            foreach (ParameterModel param in Parameters)
            {
                object paramValue = param.Value;

                if (paramValue is String)
                {
                    paramValue = paramValue.ToString().Trim();
                }

                parameters.Add(param.Name, paramValue, param.DataType, param.Direction, param.Size);
            }

            return parameters;
        }
    }
}
