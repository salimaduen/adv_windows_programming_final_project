using Final_Project;
using System.Collections.Generic;
using System;
using System.Linq;

public class PublisherService
{
    public List<publisher> GetPublishers(string searchText = null)
    {
        using (BookStoreEntities context = new BookStoreEntities())
        {
            if (string.IsNullOrEmpty(searchText))
                return context.publishers.ToList();

            searchText = searchText.ToLower();
            return context.publishers
                .Where(p => p.pub_name.ToLower().Contains(searchText) || p.pub_id.ToLower().Contains(searchText))
                .ToList();
        }
    }

    public void AddPublisher(publisher newPublisher)
    {
        using (BookStoreEntities context = new BookStoreEntities())
        {
            if (context.publishers.Any(p => p.pub_id == newPublisher.pub_id))
                throw new InvalidOperationException("Publisher already exists!");

            context.publishers.Add(newPublisher);
            context.SaveChanges();
        }
    }

    public void RemovePublisher(string pubId)
    {
        using (BookStoreEntities context = new BookStoreEntities())
        {
            var publisherToRemove = context.publishers.SingleOrDefault(p => p.pub_id == pubId);
            if (publisherToRemove == null)
                throw new InvalidOperationException("Publisher not found!");

            var relatedTitles = context.titles.Where(t => t.pub_id == pubId).ToList();
            foreach (var title in relatedTitles)
            {
                title.pub_id = null; 
            }

            var relatedEmployees = context.employees.Where(e => e.pub_id == pubId).ToList();
            foreach (var employee in relatedEmployees)
            {
                employee.pub_id = "9952"; // Assign to default pub_id
            }

            var relatedPubInfo = context.pub_info.SingleOrDefault(pi => pi.pub_id == pubId);
            if (relatedPubInfo != null)
            {
                context.pub_info.Remove(relatedPubInfo);
            }

            context.publishers.Remove(publisherToRemove);
            context.SaveChanges();
        }
    }
}
