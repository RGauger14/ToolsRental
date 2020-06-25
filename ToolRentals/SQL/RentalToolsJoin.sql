SELECT RentalItems.RentalItemId, Tools.ToolName, RentalItems.RentalId 
FROM RentalItems INNER JOIN  
Tools ON RentalItems.ToolId = Tools.ToolId  
WHERE RentalId = 1
ORDER BY RentalItems.RentalItemId DESC;

-- keep this query 