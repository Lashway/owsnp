function sensorMetaData = WSNSensorMetaData(sensorInfo,sensorId)

    for i = 1:length(sensorInfo)
        if (strcmp(sensorInfo{1,i}.Id,sensorId))
            sensorMetaData = sensorInfo{1,i};
        end
    end
end