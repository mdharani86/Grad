#blackjack db.py

import csv
import sys

import sqlite3
from contextlib import closing
from objects import Session

conn = None

def connect():
    global conn
    if not conn:
        DB_FILE = "session_db.sqlite"
        conn=sqlite3.connect(DB_FILE)
        conn.row_factory = sqlite3.Row

def close():
    global conn
    if conn:
        conn.close()

def create_session():
    query = '''CREATE TABLE IF NOT EXISTS Session (
                                                    sessionID INTEGER PRIMARY KEY,
                                                    startTime TEXT,
                                                    startMoney REAL,
                                                    stopTime TEXT,
                                                    stopMoney REAL
                                                    )
            '''
    with closing(conn.cursor()) as c:
        c.execute(query)

    result = None
    result = get_last_session()
    if result == None:
        query = ''' INSERT INTO Session (sessionID, startTime, startMoney, stopTime, stopMoney)
                                VALUES  (0, 'x', 199, 'y', 199);'''

        with closing(conn.cursor()) as c:
            c.execute(query)

        conn.commit()


def get_last_session():

    result = None
        
    query = ''' SELECT *
                FROM Session
                ORDER BY sessionID DESC;'''

    with closing(conn.cursor()) as c:
        c.execute(query)

        result = c.fetchone()
    if result == None:
        return None
    else:
        session = Session(result["sessionID"], result["startTime"], result["startMoney"], result["stopTime"], result["stopMoney"])
        return session

def add_session(s):
    # print(s)
    
    query = ''' INSERT INTO Session (sessionID, startTime, startMoney, stopTime, stopMoney)
                    VALUES (?,?,?,?,?)'''
        
    with closing(conn.cursor()) as c:
        c.execute(query,(s.sessionID,s.startTime,s.startMoney,s.stopTime,s.stopMoney))

        conn.commit()

def main():
    connect()
    create_session()
    last_s = get_last_session()
    print("Money:",last_s.stopMoney)
    new_s = Session(last_s.sessionID+1,'12:33:38 AM',99.68,'12:34:11 AM',67.24)
    print(last_s)
    print(new_s)
    print("adding session")
    add_session(new_s)
    print(get_last_session())
    close()

if __name__ == "__main__":
    main()
    
