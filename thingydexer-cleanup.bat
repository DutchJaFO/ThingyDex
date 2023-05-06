@ECHO OFF
del /Q ThingyDexer.Model\bin
del /Q ThingyDexer.Model\obj

del /Q ThingyDexer.ViewModel\bin
del /Q ThingyDexer.ViewModel\obj

del /Q ThingyDexer.View\bin
del /Q ThingyDexer.View\obj

del /Q ThingyDexer.WASM\bin
del /Q ThingyDexer.WASM\obj

@ECHO ON

docker.exe build -t thingydexer-with-docker:latest .

docker.exe run -P -d thingydexer-with-docker:latest

@REM docker run -p 32769:80 --volume=E:\temp\test:/usr/share/nginx/html --workdir=/usr/share/nginx/html -d thingydexer-with-docker:latest
