# Created by  : Viram Keshwala (viramk7@gmail.com)
# Created Date: 02 march 2019

# To run the container
# docker run --name doctorportal --rm -it -p 8000:80 <image-name>

## Ref links
# https://github.com/Microsoft/dotnet-framework-docker/blob/master/samples/aspnetmvcapp/README.md
# https://github.com/Microsoft/dotnet-framework-docker/blob/master/samples/aspnetmvcapp/Dockerfile


FROM microsoft/dotnet-framework:4.7.2-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY DoctorPortal.Web/*.csproj ./DoctorPortal.Web/
COPY DoctorPortal.Web/*.config ./DoctorPortal.Web/
RUN nuget restore

# copy everything else and build app
COPY DoctorPortal.Web/. ./DoctorPortal.Web/
WORKDIR /app/DoctorPortal.Web
RUN msbuild /p:Configuration=Release


FROM mcr.microsoft.com/dotnet/framework/aspnet:4.7.2 AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build /app/DoctorPortal.Web/. ./