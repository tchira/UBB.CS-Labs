%elimina primele 3 aparitii ale unui elem din lista
%daca apare de mai putin de 3 ori se elimina de cate
%ori apare
domains
	el=integer
	list=el*
predicates
	aparitie(el,list,el)
	elimina(el,list,list)
	elim(el,list,list,integer)
clauses
	aparitie(_,[],0):-!.
	aparitie(E,[E|T],N):-aparitie(E,T,N1),!,N=N1+1.
	aparitie(E,[_|T],N):-aparitie(E,T,N).
	
	elimina(E,L,LR):-elim(E,L,LR,3).
	elim(E,[],[],_).
	elim(E,L,L,C):-C=0,!.
	elim(E,[E|T],LR,C):-C1=C-1,elim(E,T,LR,C1).
	elim(E,[H|T],[H|LR],C):-H<>E,!,elim(E,T,LR,C).