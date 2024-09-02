from flask import Flask
from flask_sqlalchemy import SQLAlchemy

app = Flask(__name__)
app.debug = True

# adding configuration for using a sqlite database
app.config['SQLALCHEMY_DATABASE_URI'] = (
    'mssql+pyodbc://DHLBBX3/toDo?driver=ODBC+Driver+17+for+SQL+Server'
)
# Creating an SQLAlchemy instance
db = SQLAlchemy(app)

if __name__ == '__main__':
    app.run()