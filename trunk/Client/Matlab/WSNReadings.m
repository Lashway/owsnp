% eg ["f1","f2"]
function values = WSNReadings(domain,sensorID)
    %json = urlread(strcat(domain,'/WSNReadings?sensorID=',sensorID));
    json = urlread(strcat(domain));
    data = parse_json(json);

    values = cell2mat(data{1,1});
end