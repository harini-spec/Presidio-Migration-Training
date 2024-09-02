from flask import Flask, render_template, request, redirect, url_for
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
import sys
import os

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))
from Model.TaskModel import Base, Task
import Config as config

app = Flask(__name__, template_folder='../frontend')

# Database connection
connection_string = (
    f"mssql+pyodbc://{config.DATABASE_CONFIG['UID']}:{config.DATABASE_CONFIG['PWD']}"
    f"@{config.DATABASE_CONFIG['SERVER']}/{config.DATABASE_CONFIG['DATABASE']}"
    f"?driver={config.DATABASE_CONFIG['DRIVER']}"
)
engine = create_engine(connection_string)
Base.metadata.bind = engine
DBSession = sessionmaker(bind=engine)
session = DBSession()

@app.route('/')
def index():
    tasks = session.query(Task).all()
    return render_template('index.html', tasks=tasks)

@app.route('/add', methods=['POST'])
def add_task():
    task = request.form['Task']
    new_task = Task(task=task)
    session.add(new_task)
    session.commit()
    return redirect(url_for('index'))

if __name__ == '__main__':
    app.run(debug=True)