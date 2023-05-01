select Name, ContactsCount from
(
	select C.ClientName as Name, count(CC.Id) as ContactsCount
	from public.Clients as C
	inner join public.ClientContacts as CC
	on C.Id = CC.ClientId
	group by C.ClientName
)ClientsContactsCount
where ContactsCount > 2
