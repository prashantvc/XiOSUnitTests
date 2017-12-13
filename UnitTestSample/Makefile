TOUCH_SERVER=./Touch.Server.exe
TEST_RESULT=./Test_Results.xml
MTOUCH=/Developer/MonoTouch/usr/bin/mtouch

all: build-simulator build-device

run-all-tests: run-simulator run-device

build-simulator:
	msbuild /t:Rebuild

build-device:
	msbuild /t:ReBuild /p:Platform=iPhone

run-simulator: build-simulator delete-results
	mono --debug $(TOUCH_SERVER) \
	--launchsim ./bin/iPhoneSimulator/Debug/UnitTestSample.app \
	-autoexit -skipheader \
	-logfile=$(TEST_RESULT)
	--verbose \
	--device=":v2:runtime=com.apple.CoreSimulator.SimRuntime.iOS-11-2,devicetype=com.apple.CoreSimulator.SimDeviceType.iPhone-SE"

run-device: build-device delete-results
	$(MTOUCH) --installdev ./bin/iPhone/Debug/UnitTestSample.app
	mono --debug $(TOUCH_SERVER) --launchdev com.prashantvc.UnitTestSample -autoexit -skipheader -logfile=$(TEST_RESULT)

delete-results:
	rm -rf $(TEST_RESULT)