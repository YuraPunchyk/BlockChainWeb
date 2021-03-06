﻿using BlockChainWeb.Models;
using BlockChainWeb.Models.Education;
using BlockChainWeb.Models.Person;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace BlockChainWeb.DbContexts {
	public class BaseDbContext {

		#region Private Veriables
		private string ConnectionString;
		private IMongoClient _client = null;
		#endregion

		public BaseDbContext ( string connectionString ) {
			ConnectionString = connectionString;
			_client = GetConnection();
		}

		public IMongoClient GetConnection () {
			try {
				var url = new MongoUrl(ConnectionString);
				return new MongoClient(url);
			} catch(ArgumentException e) {
				e.GetBaseException();
			}
			return null;
		}

		public Login Register ( string id, string password ) {
			FilterDefinition<Login> filter = Builders<Login>.Filter.Eq(x => x.Id, id);
			filter &= Builders<Login>.Filter.Eq(x => x.Password, password);
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Login>(EnumName.Collection.LoginsCollection);
			var login = collection.Find(filter).ToList();
			if(login.Count == 1) {
				return new Login(login[0].Id, login[0].Password, login[0].IsStudent, login[0].IsTeacher, login[0].IsAdmin,
				login[0].ForwardIp);
			}

			return null;
		}
		public void UpdateLogin ( Login login ) {
			var filter = Builders<Login>.Filter.Eq(x => x.Id, login.Id);
			filter &= Builders<Login>.Filter.Eq(x => x.Password, login.Password);
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Login>(EnumName.Collection.LoginsCollection);
			var data = Builders<Login>.Update.Set(x => x, login);
			collection.UpdateOneAsync(filter, data).Wait();
		}
		public void SetUser ( Login login ) {
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Login>(EnumName.Collection.LoginsCollection);
			collection.InsertOneAsync(login).Wait();
		}

		public void SetGroup ( Group group ) {
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Group>(EnumName.Collection.GroupCollection);
			collection.InsertOneAsync(group).Wait();
		}

		public void SetSubject (Subject subject) {
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Subject>(EnumName.Collection.SubjectCollection);
			collection.InsertOneAsync(subject).Wait();
		}

		public List<Student> GetStudentsByGroup ( int group ) {
			FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(x => x.Group, group);
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Student>(EnumName.Collection.StudentCollection);
			var students = collection.Find(filter).ToList();
			return students;
		}

		public List<Student> GetStudentsByCourese ( int courese ) {
			FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(x => x.Course, courese);
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Student>(EnumName.Collection.StudentCollection);
			var students = collection.Find(filter).ToList();
			return students;
		}

		public Student GetStudentById ( string id ) {
			FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(x => x.Id, id);
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Student>(EnumName.Collection.StudentCollection);
			var student = collection.Find(filter).ToList();
			if(student.Count == 1) {
				return new Student(student[0].FullName, student[0].Faculty, student[0].Cathedra, student[0].Course, student[0].Group,
					student[0].Id, student[0].Email, student[0].Subjects);
			}
			return null;
		}
		public Login GetLoginById ( string id ) {
			FilterDefinition<Login> filter = Builders<Login>.Filter.Eq(x => x.Id, id);
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Login>(EnumName.Collection.LoginsCollection);
			var login = collection.Find(filter).ToList();
			if(login.Count == 1) {
				return new Login(login[0].Id, login[0].Password, login[0].IsStudent, login[0].IsTeacher, login[0].IsAdmin, login[0].ForwardIp);
			}
			return null;
		}


		public Teacher GetTeacherById ( string id ) {
			FilterDefinition<Teacher> filter = Builders<Teacher>.Filter.Eq(x => x.Id, id);
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Teacher>(EnumName.Collection.TeacherCollection);
			var teacher = collection.Find(filter).ToList();
			if(teacher.Count == 1) {
				return new Teacher(teacher[0].FullName, teacher[0].Faculty, teacher[0].Subjects, teacher[0].Cathedra,
					teacher[0].Id, teacher[0].Email);
			}
			return null;
		}

		public List<Group> GetGroups () {
			FilterDefinition<Group> filter = Builders<Group>.Filter.Empty;
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Group>(EnumName.Collection.GroupCollection);
			List<Group> groups = collection.Find(filter).ToList();
			return groups;
		}

		public void SetStudent ( Student student ) {
			var databasse = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = databasse.GetCollection<Student>(EnumName.Collection.StudentCollection);
			collection.InsertOneAsync(student).Wait();
		}

		public void SetTeacher ( Teacher teacher ) {
			var databasse = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = databasse.GetCollection<Teacher>(EnumName.Collection.TeacherCollection);
			collection.InsertOneAsync(teacher).Wait();
		}

		public void UpdateStudent ( Student student ) {
			var filter = Builders<Student>.Filter.Eq(x => x.Id, student.Id);
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Student>(EnumName.Collection.StudentCollection);
			var data = Builders<Student>.Update.Set("Subjects", student.Subjects);
			collection.UpdateOneAsync(filter, data).Wait();
		}

		public List<Subject> GetSubjects () {
			FilterDefinition<Subject> filter = Builders<Subject>.Filter.Empty;
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Subject>(EnumName.Collection.SubjectCollection);
			List<Subject> subjects = collection.Find(filter).ToList();
			return subjects;
		}
		public Subject GetSubjectByName (string name) {
			var filter = Builders<Subject>.Filter.Eq(x => x.Name, name);
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Subject>(EnumName.Collection.SubjectCollection);
			var subjects = collection.Find(filter).ToList();
			return subjects[0];
		}

		public void SetLogin (Login login) {
			var databasse = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = databasse.GetCollection<Login>(EnumName.Collection.LoginsCollection);
			collection.InsertOneAsync(login).Wait();
		}

		public void SetSesion(Sesion sesion ) {
			var databasse = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = databasse.GetCollection<Sesion>(EnumName.Collection.SesionCollection);
			collection.InsertOneAsync(sesion).Wait();
		}

		public Sesion GetSesion () {
			FilterDefinition<Sesion> filter = Builders<Sesion>.Filter.Empty;
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Sesion>(EnumName.Collection.SesionCollection);
			List<Sesion> sesion = collection.Find(filter).ToList();
			return sesion[sesion.Count-1];
		}

		public void DeleteSesions () {
			FilterDefinition<Sesion> filter = Builders<Sesion>.Filter.Empty;
			var database = _client.GetDatabase(EnumName.DataBase.DbName);
			var collection = database.GetCollection<Sesion>(EnumName.Collection.SesionCollection);
			collection.DeleteManyAsync(filter);
		}
	}
}