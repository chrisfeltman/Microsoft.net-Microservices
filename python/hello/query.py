import pypyodbc
import json
conn = pypyodbc.connect('DSN=Awrds2k')
cur = conn.cursor()
cur.execute('Select * from fmds.aac_lookup')
rows = cur.fetchall()
columns = [column[0] for column in cur.description]

cur.close()
conn.close()
results = []
for row in rows:
    results.append(dict(zip(columns, row)))


print json.dumps(results)

    
  
