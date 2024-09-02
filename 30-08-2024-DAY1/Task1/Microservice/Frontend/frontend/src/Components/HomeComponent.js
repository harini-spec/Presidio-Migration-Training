import React, { useEffect, useState } from 'react';
import axios from 'axios';
import '../Styles/HomeStyles.css';

const HomeComponent = () => {
    const [tasks, setTasks] = useState([]);
    const [editingTaskId, setEditingTaskId] = useState(null);
    const [newTaskContent, setNewTaskContent] = useState('');

    useEffect(() => {
        // Fetch data from the Flask backend
        axios.get('http://localhost:5000/get/AllTasks')
            .then(response => {
                setTasks(response.data);
            })
            .catch(error => {
                console.error('There was an error fetching the tasks!', error);
            });
    }, []);

    const addTask = (event) => {
        event.preventDefault();
        const newTask = { task: event.target.Task.value };

        axios.post('http://localhost:5000/add', newTask)
            .then(response => {
                setTasks([...tasks, response.data]);
                event.target.reset();
            })
            .catch(error => {
                console.error('There was an error adding the task!', error);
            });
    };

    const deleteTask = (taskId) => {
        axios.delete(`http://localhost:5000/delete/${taskId}`)
            .then(response => {
                setTasks(tasks.filter(task => task.id !== taskId));
            })
            .catch(error => {
                console.error('There was an error deleting the task!', error);
            });
    };

    const startEditing = (taskId, currentTask) => {
        setEditingTaskId(taskId);
        setNewTaskContent(currentTask);
    };

    const updateTask = (taskId) => {
        axios.put(`http://localhost:5000/update/${taskId}`, { task: newTaskContent })
            .then(response => {
                setTasks(tasks.map(task => task.id === taskId ? response.data.task : task));
                setEditingTaskId(null);
                setNewTaskContent('');
            })
            .catch(error => {
                console.error('There was an error updating the task!', error);
            });
    };

    return (
        <div className='main-container'>
            <h1>Task List</h1>
            <form onSubmit={addTask}>
                <input className='form-control' type="text" name="Task" placeholder="Enter a Task" required />
                <button className='btn btn-primary' type="submit">Add Task</button>
            </form>
                <div>
                {tasks.map((task) => (
                    <p key={task.id} className='task-main-container'>
                        <hr/>
                        {editingTaskId === task.id ? (
                            <div className='task-container'>
                                <div className='task'>
                                    <input
                                        className='form-control edit-form'
                                        type="text"
                                        value={newTaskContent}
                                        onChange={(e) => setNewTaskContent(e.target.value)}
                                    />
                                </div>
                                <div className='buttons'>
                                    <button className='btn btn-primary'  onClick={() => updateTask(task.id)}>Update</button>
                                    <button className='btn btn-primary' onClick={() => setEditingTaskId(null)}>Cancel</button>
                                </div>
                            </div>
                        ) : (
                            <div className='task-container'>
                                <div className='task'>
                                    {task.task}
                                </div>
                                <div className='buttons'>
                                    <div className='btn btn-primary' onClick={() => startEditing(task.id, task.task)}>Edit</div>
                                    <div className='btn btn-danger' onClick={() => deleteTask(task.id)}>Delete</div>
                                </div>
                            </div>
                        )}
                    </p>
                ))}
                <hr/>
            </div>
        </div>
    );
}

export default HomeComponent;
