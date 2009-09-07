function [sensorId] = WSNSensorIds(sensorInfo)

    for i = 1:length(sensorInfo)
        sensorId =+ sensorInfo{1,i}.Id;
    end
end