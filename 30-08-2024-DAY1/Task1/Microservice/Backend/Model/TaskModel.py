from sqlalchemy import Column, Integer, String, create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
import Config as config

# Define the base class
Base = declarative_base()

# Define the Task model
class Task(Base):
    __tablename__ = 'tasks'
    id = Column(Integer, primary_key=True)
    task = Column(String(50))

    def to_dict(self):
        return {
            'id': self.id,
            'task': self.task
        }

# Define the connection string
connection_string = (
    f"mssql+pyodbc://{config.DATABASE_CONFIG['UID']}:{config.DATABASE_CONFIG['PWD']}"
    f"@{config.DATABASE_CONFIG['SERVER']}/{config.DATABASE_CONFIG['DATABASE']}"
    f"?driver={config.DATABASE_CONFIG['DRIVER']}"
)
# Create an engine connected to your database
engine = create_engine(connection_string)

# Create all tables in the database (equivalent to "CREATE TABLE" in raw SQL)
Base.metadata.create_all(engine)

# Optionally, create a session to interact with the database
Session = sessionmaker(bind=engine)
session = Session()

# You can now use `session` to add, query, delete, etc. tasks in the database.
