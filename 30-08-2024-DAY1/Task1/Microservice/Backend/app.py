from flask import Flask, render_template, request, redirect, url_for
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
import sys
import os
from flask import jsonify
from flask_cors import CORS

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))
from Model.TaskModel import Base, Task
import Config as config

app = Flask(__name__, template_folder='../frontend')
CORS(app, resources={r"/*": {"origins": "*", "methods": ["GET", "POST", "DELETE", "PUT", "OPTIONS"], "allow_headers": ["Content-Type"]}})


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

@app.route('/get/AllTasks', methods=['GET'])
def get_all_tasks():
    tasks = session.query(Task).all()
    tasks_dict = [task.to_dict() for task in tasks]  # Assuming you have a to_dict() method in Task model
    return jsonify(tasks_dict)

@app.route('/delete/<int:task_id>', methods=['DELETE'])
def delete_task(task_id):
    task = session.query(Task).filter_by(id=task_id).first()
    if task:
        session.delete(task)
        session.commit()
        return jsonify({"message": "Task deleted successfully!"}), 200
    else:
        return jsonify({"error": "Task not found"}), 404

@app.route('/update/<int:task_id>', methods=['PUT'])
def update_task(task_id):
    data = request.get_json()  # Parse JSON data
    new_task_content = data.get('task')
    task = session.query(Task).filter_by(id=task_id).first()

    if task and new_task_content:
        task.task = new_task_content
        session.commit()
        return jsonify({"message": "Task updated successfully!", "task": task.to_dict()}), 200
    else:
        return jsonify({"error": "Task not found or invalid data"}), 400

@app.route('/add', methods=['POST'])
def add_task():
    data = request.get_json()  # Assuming JSON data
    task = data.get('task')
    if task:
        new_task = Task(task=task)
        session.add(new_task)
        session.commit()
        return jsonify(new_task.to_dict()), 201
    else:
        return jsonify({"error": "Task content is missing"}), 400


if __name__ == '__main__':
    app.run(debug=True)