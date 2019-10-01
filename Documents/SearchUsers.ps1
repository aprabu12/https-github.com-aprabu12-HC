 Invoke-RestMethod -Uri https://localhost:44340/api/users -Method Get;
 $data =Invoke-RestMethod -Uri https://localhost:44340/api/users -Method Get;
 $data.Count
 $data.Where({$_.userID},'Default',13)
 $data.Where({$_.lastName -eq 'jones'})






