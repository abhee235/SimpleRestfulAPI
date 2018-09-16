SELECT r.id,
       r.age,
       w.name as WorkClass,
       e.name as Education,
       r.education_num,
       m.name as marital_status,
       o.name as Occupation,
       rel.name as Relationship,
       rac.name as Race,
       s.name as Sex,
       capital_gain,
       capital_loss,
       hours_week,
       c.name as Country,
       over_50k
  FROM records r INNER JOIN workclasses w ON r.workclass_id = w.id
  INNER JOIN marital_statuses m ON r.marital_status_id = m.id
  INNER JOIN  education_levels e ON r.education_level_id = e.id 
  INNER JOIN occupations o ON r.occupation_id = o.id
  INNER JOIN relationships rel ON r.relationship_id = rel.id
  INNER JOIN races rac ON r.race_id = rac.id
  INNER JOIN sexes s ON s.id = r.sex_id
  INNER JOIN countries c ON c.id = r.country_id
