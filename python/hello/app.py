
from flask import Flask, jsonify
import json
import pypyodbc

app = Flask(__name__)
@app.route('/aac_lookup')

def index():
    conn = pypyodbc.connect('DSN=Awrds2k')
    cur = conn.cursor()
    cur.execute('Select * from fmds.aac_lookup')
    result = jsonifyQuery(cur)
    
    cur.close()
    conn.close()
  
    return result


def jsonifyQuery(cursor):
    rows = cursor.fetchall()
    columns = [column[0] for column in cursor.description]
    results = []
    for row in rows:
        results.append(dict(zip(columns, row)))
    return json.dumps(results)

    
if __name__ == '__main__':
    app.run(debug=True)
