CREATE FUNCTION [dbo].[GetSortableDeploiements]
(
	@datetime as datetime
)
RETURNS TABLE AS RETURN
(
	select		 d.[Id]									as [Id]
				,d.[ComposantId]						as [ComposantId]
				,c.[Nom]								as [ComposantNom]
				,c.[Abreviation]						as [ComposantAbreviation]
				,d.[EnvironnementId]					as [EnvironnementId]
				,e.[Nom]								as [EnvironnementNom]
				,d.[Date]								as [Date]
				,d.[BrancheTag]							as [BrancheTag]
				,d.[URLDestination]						as [URLDestination]
				,d.[PortailGroupe]						as [PortailGroupe]
				,d.[PortailDescription]					as [PortailDescription]
				,d.[Details]							as [Details]
				,d.[DerniereMAJ]						as [DerniereMAJ]
				,d.[PremierDeploiement]					as [PremierDeploiement]
				,d.[Web]								as [Web]
				,d.[BD]									as [BD]
				,d.[Rapport]							as [Rapport]
				,d.[Interface]							as [Interface]
				,d.[Job]								as [Job]
				,case when @datetime > d.[Date]
				 then cast(1 as bit)
				 else cast(0 as bit)
				 end									as [EstPasse]
				,abs(datediff(mi, @datetime, d.[Date]))	as [EcartMinutes]

	from		 [dbo].[Deploiement] d
	inner join	 [dbo].[Composant] c
		on		 c.[Id] = d.[ComposantId]
	inner join	 [dbo].[Environnement] e
		on		 e.[Id]	= d.[EnvironnementId]

)
